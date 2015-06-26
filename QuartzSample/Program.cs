using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzSample
{
    class Program
    {
        static void Main(string[] args)
        {
            JobCreator.Start();
        }
    }
    public class MyJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            Console.WriteLine(DateTime.Now);
        }
    }
    public class JobCreator
    {
        public static void Start()
        {
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();
            IJobDetail job = JobBuilder.Create<MyJob>().Build();
            ITrigger trigger = TriggerBuilder.Create().StartNow().WithSimpleSchedule(x =>
                x.WithIntervalInSeconds(10).RepeatForever()
                ).Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}
