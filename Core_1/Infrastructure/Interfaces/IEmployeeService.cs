﻿using Core_1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core_1.Infrastructure.Interfaces
{
    public interface IEmployeeService
    {
        /// <summary>
        /// Получение списка сотрудников
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeViewModel> GetAll();

        /// <summary>
        /// Получение сотрудника по id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns></returns>
        EmployeeViewModel GetById(int id);

        /// <summary>
        /// Сохранить изменения
        /// </summary>
        void Commit();

        /// <summary>
        /// Добавить нового
        /// </summary>
        /// <param name="model"></param>
        void AddNew(EmployeeViewModel model);

        /// <summary>
        /// Удалить
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
