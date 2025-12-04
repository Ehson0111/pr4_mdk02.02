// <copyright file="TodoItem.cs" company="Todo.Core01">
// </copyright>

using System;

namespace Todo.Core01
{
    /// <summary>
    /// Представляет элемент списка задач.
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Получает уникальный идентификатор задачи.
        /// </summary>
        public Guid Id { get; } = Guid.NewGuid();

        /// <summary>
        /// Получает или задает заголовок задачи.
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Получает или задает значение, указывающее, выполнена ли задача.
        /// </summary>
        public bool IsDone { get; private set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="TodoItem"/>.
        /// </summary>
        /// <param name="title">Заголовок задачи.</param>
        /// <exception cref="ArgumentNullException">
        /// Возникает, если <paramref name="title"/> является null.
        /// </exception>
        public TodoItem(string title)
        {
            Title = title?.Trim() ?? throw new ArgumentNullException(nameof(title));
        }

        /// <summary>
        /// Отмечает задачу как выполненную.
        /// </summary>
        public void MarkDone()
        {
            IsDone = true;
        }

        /// <summary>
        /// Отмечает задачу как невыполненную.
        /// </summary>
        public void MarkUndone()
        {
            IsDone = false;
        }

        /// <summary>
        /// Переименовывает задачу.
        /// </summary>
        /// <param name="newTitle">Новый заголовок задачи.</param>
        /// <exception cref="ArgumentException">
        /// Возникает, если <paramref name="newTitle"/> является null или состоит только из пробелов.
        /// </exception>
        public void Rename(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                throw new ArgumentException("Title is required", nameof(newTitle));
            }

            Title = newTitle.Trim();
        }
    }
}