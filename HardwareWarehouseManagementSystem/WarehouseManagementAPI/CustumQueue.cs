using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseManagementAPI
{
    public delegate void QueueEventHandler<T, U>(T sender, U eventArgs);

    public class CustumQueue<T> where T : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        Queue<T> _queue = null;

        public event QueueEventHandler<CustumQueue<T>, QueueEventArgs> CustomQueueEvent; 

        public CustumQueue() 
        {
            _queue = new Queue<T>();
        }

        public int QueueLength 
        {
            get { return _queue.Count; }
        }

        public void AddItem(T item) 
        { 
            _queue.Enqueue(item);

            OnQueueChanged(new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id({item.Id}), Name({item.Name}), Type({item.Type}), Quantity({item.Quantity}), has been added to the queue."});
        }

        public T GetItem() 
        {
            var item = _queue.Dequeue();
            OnQueueChanged(new QueueEventArgs { Message = $"DateTime: {DateTime.Now.ToString(Constants.DateTimeFormat)}, Id({item.Id}), Name({item.Name}), Type({item.Type}), Quantity({item.Quantity}), has been processed." });

            return item;
        }

        protected virtual void OnQueueChanged(QueueEventArgs args) 
        {
            CustomQueueEvent?.Invoke(this, args); 
        }

        public IEnumerator<T> GetEnumerator() 
        {
            return _queue.GetEnumerator();
        }
    }

    public class QueueEventArgs: EventArgs
    {
        public string Message {  get; set; }

    }
}
