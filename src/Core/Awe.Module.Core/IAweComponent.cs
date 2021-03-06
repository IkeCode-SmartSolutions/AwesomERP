﻿namespace Awe.Module.Core
{

    public interface IAweComponent
    {
        string Name { get; }
        string Description { get; }
        int? Order { get; }

        void RegisterServices();
    }
}
