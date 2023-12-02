namespace AdventOfCode;

public static class TaskSolutionRunner
{
    public static void Run<T>()
        where T : ITaskSolution, new()
    {
        new T().Run();
    }
}