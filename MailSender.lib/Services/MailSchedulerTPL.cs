﻿using System;
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


        public MailSchedulerTPL(ISchedulerTasksStore TasksStore)
        {
            _TasksStore = TasksStore;
        }
         
        public async Task StartAsync()
        {
            var cancellation = new CancellationTokenSource();
            Interlocked.Exchange(ref _ProcessTaskCancellation, cancellation)?.Cancel();//отменяем предыдущую задачу

            var first_task = _TasksStore.GetAll()
               .Where(task => task.Time > DateTime.Now)
               .OrderBy(task => task.Time)
               .FirstOrDefault();
            if (first_task is null) return;

            WaitTaskAsync(first_task, cancellation.Token);
        }

        private async void WaitTaskAsync(SchedulerTask task, CancellationToken Cancel)
        {
            var task_time = task.Time; //извлечение времени
            var delta = task_time.Subtract(DateTime.Now); //найти сколько спать

            await Task.Delay(delta, Cancel).ConfigureAwait(false); //поспать

            await ExecuteTask(task, Cancel); //разослать почту
            _TasksStore.Remove(task.Id);//удалить задачу

            await StartAsync();
        }

        private async Task ExecuteTask(SchedulerTask task, CancellationToken Cancel)
        {

        }
    }
}