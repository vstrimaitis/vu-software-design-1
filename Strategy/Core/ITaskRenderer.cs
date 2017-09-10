﻿namespace Strategy.Core
{
    interface ITaskRenderer
    {
        string RenderTaskHeader(Task t);
        string RenderTaskBody(Task t);
    }
}