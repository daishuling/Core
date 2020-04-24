using CoreDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Services
{
    public interface ICinemaService
    {
        Task<IEnumerable<Cinema>> GetllAllAsync();//查询所有的Cinema值
        Task<Cinema> GetByIdAsync(int id);//查询指定ID的Cinema
       // Task<Sales> GetSalesAsync();
        Task AddAsync(Cinema model);//创建Cinema值
    }
}
