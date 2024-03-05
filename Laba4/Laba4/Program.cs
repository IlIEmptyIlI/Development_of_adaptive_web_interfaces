using System;
using System.Reflection;
using Laba4;

class Program
{
    static void Main(string[] args)
    {
        Student john = new Student(1, "John", 20, 3.8, true);
        Student emily = new Student(2, "Emily", 22, 3.5, false);

        Type studentType = typeof(Student);
        TypeInfo studentTypeInfo = studentType.GetTypeInfo();

        Console.WriteLine($"Тип: {studentType.Name}");
        Console.WriteLine("\nЧлены:");
        foreach (MemberInfo memberInfo in studentTypeInfo.GetMembers())
        {
            Console.WriteLine($"Имя: {memberInfo.Name} ({memberInfo.MemberType})");
        }

        Console.WriteLine("\nПоля:");
        foreach (FieldInfo fieldInfo in studentTypeInfo.DeclaredFields)
        {
            Console.WriteLine($"Имя поля: {fieldInfo.Name}, Модификатор доступа: {fieldInfo.Attributes}, Тип: {fieldInfo.FieldType}");
        }

        Console.WriteLine("\nМетоды:");
        foreach (MethodInfo methodInfo in studentTypeInfo.DeclaredMethods)
        {
            Console.WriteLine($"Имя метода: {methodInfo.Name}, Модификатор доступа: {methodInfo.Attributes}, Возвращаемый тип: {methodInfo.ReturnType}");
        }

        Console.WriteLine("\nReflection:");
        MethodInfo reflectionMethod = studentType.GetMethod("WriteInfo");
        if (reflectionMethod != null)
        {
            reflectionMethod.Invoke(john, null);
        }
    }
}