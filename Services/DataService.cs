using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TamagotchiTodo.Models;

namespace TamagotchiTodo.Services
{
    public class DataService
    {
        private readonly string _dataDirectory;
        private readonly string _tasksFile;
        private readonly string _petFile;

        public DataService()
        {
            _dataDirectory = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "TamagotchiTodo"
            );
            _tasksFile = Path.Combine(_dataDirectory, "tasks.json");
            _petFile = Path.Combine(_dataDirectory, "pet.json");

            EnsureDataDirectoryExists();
        }

        private void EnsureDataDirectoryExists()
        {
            if (!Directory.Exists(_dataDirectory))
            {
                Directory.CreateDirectory(_dataDirectory);
            }
        }

        public List<TodoTask> LoadTasks()
        {
            try
            {
                if (File.Exists(_tasksFile))
                {
                    var json = File.ReadAllText(_tasksFile);
                    return JsonConvert.DeserializeObject<List<TodoTask>>(json) ?? new List<TodoTask>();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading tasks: {ex.Message}");
            }

            return new List<TodoTask>();
        }

        public void SaveTasks(List<TodoTask> tasks)
        {
            try
            {
                var json = JsonConvert.SerializeObject(tasks, Formatting.Indented);
                File.WriteAllText(_tasksFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving tasks: {ex.Message}");
            }
        }

        public TamagotchiPet LoadPet()
        {
            try
            {
                if (File.Exists(_petFile))
                {
                    var json = File.ReadAllText(_petFile);
                    var pet = JsonConvert.DeserializeObject<TamagotchiPet>(json);
                    if (pet != null)
                    {
                        // Apply stat decay based on time elapsed
                        var timeSinceLastUpdate = DateTime.Now - pet.LastUpdated;
                        var hoursElapsed = (int)timeSinceLastUpdate.TotalHours;

                        if (hoursElapsed > 0)
                        {
                            pet.Stats.DecayStats(Math.Min(hoursElapsed, 50)); // Cap decay
                        }

                        pet.LastUpdated = DateTime.Now;
                        pet.UpdateMood();
                        return pet;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading pet: {ex.Message}");
            }

            return new TamagotchiPet();
        }

        public void SavePet(TamagotchiPet pet)
        {
            try
            {
                pet.LastUpdated = DateTime.Now;
                var json = JsonConvert.SerializeObject(pet, Formatting.Indented);
                File.WriteAllText(_petFile, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving pet: {ex.Message}");
            }
        }
    }
}
