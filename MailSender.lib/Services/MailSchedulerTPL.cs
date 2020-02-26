using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailSender.lib.Entities;
using MailSender.lib.Services.Interfaces;

namespace MailSender.lib.Services
{
    public class MailSchedulerTPL
    {
        private readonly ISchedulerTasksStore _TasksStore; //источник заданий планировщика
        private volatile CancellationTokenSource _ProcessTaskCancellation;
        private readonly IMailSenderService _MailSenderService;


        public MailSchedulerTPL(ISchedulerTasksStore TasksStore, IMailSenderService MailSenderService)
        {
            _TasksStore = TasksStore;
            _MailSenderService = MailSenderService;
        }
         
        public void Start()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _ProcessTaskCancellation, cancellation)?.Cancel();//отменяем предыдущую задачу

            var first_task = _TasksStore.GetAll()
               .Where(task => task.Time > DateTime.Now) //выбираем время больше чем текущее
               .OrderBy(task => task.Time) //упорядовычение по времени
               .FirstOrDefault(); //берем первое
            if (first_task is null) return;

            WaitTaskAsync(first_task, cancellation.Token); //ожидание задачи
        }

        private async void WaitTaskAsync(SchedulerTask task, CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();

            var task_time = task.Time; //извлечение времени
            var delta = task_time.Subtract(DateTime.Now); //найти сколько спать

            if (delta.TotalSeconds > 0)
                await Task.Delay(delta, Cancel).ConfigureAwait(false);//поспать
            Cancel.ThrowIfCancellationRequested();

            await ExecuteTask(task, Cancel); //разослать почту
            _TasksStore.Remove(task.Id);//удалить задачу

            await Task.Run(() => Start()) ; //перезапуск задания
        }

        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {
            Cancel.ThrowIfCancellationRequested();

            var adresser = _MailSenderService.GetSender(task.Server); //получение отправителя из сервиса
            await adresser.SendAsync(task.Mail, task.Adresser, task.Adressees.Adressees, Cancel); //запуск процедуры рассылки
        }
    }
}