using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS04_Advanced
{
     class AltProgram
    {
        public  void AltResultAnnouncer(object sender, TaskPerformedEventArgs eventArgs)
        {
            Console.WriteLine($"Alternative was completed in {eventArgs.Seconds / eventArgs.Persons} seconds!");
        }

        public  void RunSubscriber()
        {
            TaskContainerSEP taskContainer = new TaskContainerSEP();
            taskContainer.TaskPerformed += AltResultAnnouncer;
            taskContainer.DoTask(1, 1);
        }
    }
}
