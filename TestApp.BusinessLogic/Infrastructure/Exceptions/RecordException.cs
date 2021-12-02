using System;
using System.Runtime.Serialization;

namespace TestApp.BusinessLogic.Infrastructure.Exceptions
{
    public class RecordException : Exception
    {
        public RecordException() : base() { }
       
        public RecordException(string message) : base(message) { }
        
        public RecordException(string message, Exception innerException) : base(message, innerException) { }
        
        /// <summary>
        /// Инициализирует новый экземпляр класса RecordException с сериализованными данными.
        /// </summary>
        /// <param name="info">
        /// Объект System.Runtime.Serialization.SerializationInfo, хранящий сериализованные
        /// данные объекта, относящиеся к выдаваемому исключению.
        /// </param>
        /// <param name="context">
        /// Объект System.Runtime.Serialization.StreamingContext, содержащий контекстные
        /// сведения об источнике или назначении.
        /// </param>
        protected RecordException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string ToString()
        {
            return Message;
        }
    }
}
