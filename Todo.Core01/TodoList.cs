// --------------------------------------------------------------------------
// <copyright file="TodoItem.cs" company="NATK">
//  Copyright (c) NATK. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

namespace Todo.Core01
{
    /// <summary>
    /// Представляет список задач.
    /// </summary>
    public class TodoList
    {
        private readonly List<TodoItem> items = new();

        /// <summary>
        /// Получает доступный только для чтения список элементов задач.
        /// </summary>
        public IReadOnlyList<TodoItem> Items => items.AsReadOnly(); // comment test

        /// <summary>
        /// Добавляет новую задачу в список.
        /// </summary>
        /// <param name="title">Заголовок новой задачи.</param>
        /// <returns>Созданный элемент задачи.</returns>
        public TodoItem Add(string title)
        {
            TodoItem item = new(title);
            items.Add(item);
            return item;
        }

        /// <summary>
        /// Удаляет задачу по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор задачи для удаления.</param>
        /// <returns>
        /// <c>true</c>, если задача была удалена; в противном случае <c>false</c>.
        /// </returns>
        public bool Remove(Guid id)
        {
            return items.RemoveAll(i => i.Id == id) > 0;
        }

        /// <summary>
        /// Находит задачи, содержащие указанную подстроку в заголовке.
        /// </summary>
        /// <param name="substring">Подстрока для поиска.</param>
        /// <returns>Перечисление найденных задач.</returns>
        public IEnumerable<TodoItem> Find(string substring)
        {
            return items.Where(i =>
                i.Title.Contains(substring ?? string.Empty, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Получает количество задач в списке.
        /// </summary>
        public int Count => items.Count;
    }
}