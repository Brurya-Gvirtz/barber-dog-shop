using BarberShop.DAL;
using BarberShop.Entities;
using System.Collections.Generic;

namespace BarberShop.BL
{
    public class QueueManager
    {
       public static List<QueueCustomer> GetAllQueues()
        {
            return QueueRepository.GetAllQueues();
        }

        public static Queue AddQueue(Queue queue)
        {
            return QueueRepository.AddQueue(queue);
        }

        public static Queue UpdateQueue(string id,Queue queue)
        {
            return QueueRepository.UpdateQueue(id,queue);
        }

        public static void DeleteQueue(string id)
        {
            QueueRepository.DeleteQueue(id);
        }

        public static int GetQueuesCount(string id)
        {
            return QueueRepository.GetQueuesCount(id);
        }
    }
}
