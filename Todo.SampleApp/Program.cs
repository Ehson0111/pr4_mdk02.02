using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Core01;

namespace Todo.SampleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Todo Sample App ===");

            var todoList = new TodoList();

            // Добавляем задачи
            var item1 = todoList.Add("Купить хлеб");
            var item2 = todoList.Add("Сделать домашку");

            Console.WriteLine($"Всего задач: {todoList.Count}");

            // Выводим все задачи
            foreach (var item in todoList.Items)
            {
                Console.WriteLine($"- {item.Title} [{(item.IsDone ? "✓" : " ")}]");
            }

            // Отмечаем одну как выполненную
            item1.MarkDone();
            Console.WriteLine($"\nЗадача '{item1.Title}' выполнена!");

            // Поиск задач
            Console.WriteLine("\nПоиск 'хлеб':");
            foreach (var item in todoList.Find("хлеб"))
            {
                Console.WriteLine($"Найдено: {item.Title}");
            }

            // Удаление задачи
            if (todoList.Remove(item2.Id))
            {
                Console.WriteLine($"\nЗадача '{item2.Title}' удалена!");
            }

            Console.WriteLine($"\nОсталось задач: {todoList.Count}");
    }
    }
}
