using System;

namespace LibBusinessLayer.BIL.Infrastructure
{
    public class ValidationException : Exception
    {
        //Это свойство позволяет сохранить название свойства модели, которое некорректно и не проходит валидацию.
        public string Property { get; protected set; }
        public ValidationException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
