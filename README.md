# Quartz-with-ASP.Net-Core
This project is an example of what Quartz.Net framework is and how can it be used in ASP.NET Core Web application

## Getting Started
Before you proceed further, please make sure you've basic understanding of how ASP.NET Core MVC web application works. Also you need to have some basic idea about Quartz.Net framework. You can find useful information from the following **[link](https://www.quartz-scheduler.net/)**. You can also refer to these videos to see things in action. We will be using a nuget package offered by Quartz called **[Quartz](https://www.nuget.org/packages/Quartz/)**

[Getting Started with ASP.NET Core and Quartz.Net](https://youtu.be/2VgQDIW0ifk)


### Step 1
Download Quartz nuget package into the project

### Step 2
Now we need to configure Quartz within our **Startup.cs** class. To do that, we will be creating a new instance of **SchedulerFactory** and then registering it so that it can be accessed across the application through **Dependency Injection**

```
    private IScheduler GetScheduler()
        {
            var properties = new NameValueCollection
            {
                ["quartz.scheduler.instanceName"] = "QuartzWithCore",
                ["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz",
                ["quartz.threadPool.threadCount"] = "3",
                ["quartz.jobStore.type"] = "Quartz.Simpl.RAMJobStore, Quartz",
            };
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler().Result;
            scheduler.Start();
            return scheduler;
        }
```
Once the instance is created, we will register it in ConfigureServices method in Startup.cs class

```
services.AddSingleton(provider => GetScheduler());
```
### Step 3
We need to create few implementations that will have the actual code to do some of the operations. The implementations classes should implement **[IJob]()** interface offered by Quartz. When Quartz is execting, it automatically starts with **Execute** method. 

```
public class SomeJob : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            // do something here
            return Task.FromResult(0);
        }
    }
```
### Step 4
Create a method that will schedule the job into Quartz. To schedule a job, there are two parts 1. Setup the Trigger with details like when to start the job, how often to run, is it once or execute at regular intervals, etc. 

```
ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity($"Check Availability-{DateTime.Now}")
             .StartNow()
             .WithPriority(1)
             .Build();
```
2. Setup the job with information about the implementations, attach data to the context, specify the identity to the job.

```
IJobDetail job = JobBuilder.Create<SomeTask>()
                        .WithIdentity("Some Unique ID")
                        .Build(); 
``` 
  Once the trigger and the job is initialized correct, we can schedule the job into Quartz
  
```
   _scheduler.ScheduleJob(job, trigger);
```  
Connect the UI element to the method and see the flow in action

## License
This project is open source.

##### Thank you
