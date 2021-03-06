﻿using System;
using ToDoApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ToDoApi.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ToDoDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ToDoDbContext>>()))
            {
                if (context.ToDoItems.Any() || context.ToDoLists.Any())
                {
                    return;
                }

                context.ToDoItems.AddRange(
                    new ToDoItem
                    {
                        Name = "Item 1",
                        IsDone = false,
                        ListID = 1
                    },
                    new ToDoItem
                    {
                        Name = "Item 2",
                        IsDone = true,
                        ListID = 1
                    },
                    new ToDoItem
                    {
                        Name = "Item 3",
                        IsDone = false,
                        ListID = 1
                    }
                   );
                context.SaveChanges();

                context.ToDoLists.AddRange(
                    new ToDoList
                    {
                        Name = "Default List",
                        IsDone = false
                    }
                   );
                context.SaveChanges();
            }
        }
    }
}
