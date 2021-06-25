using System;
using System.Threading;

namespace CS04_Advanced
{
    public delegate void TaskPerformedHandler(int seconds, int persons);
    static class TaskContainer
    {
        public static event TaskPerformedHandler TaskPerformed; //Event Definition

        public static  void DoTask(int seconds, int persons)
        {
            Thread.Sleep(seconds*1000/persons); //Perform Task
            OnTaskPerformed(seconds, persons); //After Task is Complete, Call the Method with the Event
        }

        public static void OnTaskPerformed(int seconds, int persons)
        {
            TaskPerformed?.Invoke(seconds, persons); //Event Raise
        }
    }
}
