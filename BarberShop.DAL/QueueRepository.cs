using BarberShop.Context;
using BarberShop.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BarberShop.DAL
{
    public class QueueRepository
    {
        private static DatabaseContext db = new DatabaseContext();

        public static List<QueueCustomer> GetAllQueues()
        {
            List<QueueCustomer> queues = new List<QueueCustomer>();

            var lists = (from c in db.Customers
                         join q in db.Queues on c.Id equals q.CustomerID
                         select new { c.Name, q.ArrivalTime, q.CreatedOn, q.Id, q.CustomerID }).ToList();
            foreach (var item in lists)
            {
                if (item.ArrivalTime > DateTime.Now)
                {
                    QueueCustomer qc = new QueueCustomer();
                    qc.Id = item.Id;
                    qc.CreatedOn = item.CreatedOn;
                    qc.ArrivalTime = item.ArrivalTime;
                    qc.CustomerId = item.CustomerID;
                    qc.CustomerName = item.Name;
                    queues.Add(qc);
                }
            }
            queues=queues.OrderBy(q => q.ArrivalTime).ToList();
            return queues;
        }
        public static Queue AddQueue(Queue data)
        {
            Queue queue = new Queue() { ArrivalTime = data.ArrivalTime, CreatedOn = DateTime.Now, CustomerID = data.CustomerID };
            db.Queues.Add(queue);
            db.SaveChanges();
            return queue;
        }

        public static Queue UpdateQueue(string id, Queue data)
        {
            Queue queue = db.Queues.Where(q => q.Id == id).First();
            queue.ArrivalTime = data.ArrivalTime;
            queue.CreatedOn = DateTime.Now;
            db.SaveChanges();
            return queue;
        }

        public static void DeleteQueue(string id)
        {
            Queue queue = db.Queues.Where(q => q.Id == id).First();
            db.Queues.Remove(queue);
            db.SaveChanges();
        }

        public static Queue GetQueueById(string id)
        {
            return db.Queues.Where(q => q.Id == id).First();
        }

        public static int GetQueuesCount(string id)
        {
            var outParam = new SqlParameter();
            outParam.ParameterName = "RowCount";
            outParam.SqlDbType = SqlDbType.Int;
            outParam.Direction = ParameterDirection.Output;

            var data = db.Database.SqlQuery<List<Queue>>("GetQueuesCount @CustomerId, @RowCount OUT",
                           new SqlParameter("CustomerId", id),
                           outParam);
            var result = data.ToList();
            int count = (int)outParam.Value;
            return count;
        }
    }
}
