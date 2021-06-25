using System;
using System.Threading;

namespace CS04_Advanced
{
    class TaskContainerSEP
    {
        public event EventHandler<TaskPerformedEventArgs> TaskPerformed; //Event Definition

        public virtual void DoTask(int seconds, int persons)
        {
            Thread.Sleep(seconds * 1000 / persons); //Perform Task
            OnTaskPerformed(seconds, persons); //After Task is Complete, Call the Method with the Event
        }

        protected virtual void OnTaskPerformed(int seconds, int persons)
        {
            TaskPerformed?.Invoke(this, new TaskPerformedEventArgs(seconds, persons)); //Event Raise
        }
    }

    public class TaskPerformedEventArgs : EventArgs
    {
        public int Seconds { get; set; }
        public int Persons { get; set; }

        public TaskPerformedEventArgs(int seconds, int persons) //Constructor
        {
            Seconds = seconds;
            Persons = persons;
        }
    }
}