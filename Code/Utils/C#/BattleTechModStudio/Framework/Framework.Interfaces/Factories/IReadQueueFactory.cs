﻿namespace Framework.Interfaces.Factories
{
    using System;
    using Queue;

    public interface IReadQueueFactory<TRequestType> : IDisposable
        where TRequestType : class
    {
        IReadQueue<TRequestType> Create();

        IReadQueue<TRequestType> Create(IQueueBase cloneSource, int? id);

        void Release(IReadQueue<TRequestType> queue);
    }
}