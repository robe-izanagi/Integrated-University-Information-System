using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace IntegratedUniversityInformationSystem.Repositories
{
    public class JsonRepository<T> where T : class
    {
        private readonly string _filePath;
        private List<T> _items;

        public JsonRepository(string filePath)
        {
            _filePath = filePath;
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                if (File.Exists(_filePath))
                {
                    string json = File.ReadAllText(_filePath);
                    _items = JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
                }
                else
                {
                    _items = new List<T>();
                    SaveData();
                }
            }
            catch (JsonException)
            {
                _items = new List<T>();
            }
            catch (IOException)
            {
                _items = new List<T>();
            }
        }

        private void SaveData()
        {
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(_items, options);
                File.WriteAllText(_filePath, json);
            }
            catch (IOException)
            {
                throw;
            }
        }

        public List<T> GetAll()
        {
            return _items;
        }

        public T GetById(Func<T, bool> predicate)
        {
            return _items.FirstOrDefault(predicate);
        }

        public void Add(T item)
        {
            _items.Add(item);
            SaveData();
        }

        // FIXED Update method
        public void Update(Func<T, bool> predicate, T updatedItem)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (predicate(_items[i]))
                {
                    _items[i] = updatedItem;
                    SaveData();
                    return;
                }
            }
        }

        public void Delete(T item)
        {
            _items.Remove(item);
            SaveData();
        }

        public void DeleteBy(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item != null)
            {
                _items.Remove(item);
                SaveData();
            }
        }

        public void Refresh()
        {
            LoadData();
        }
    }
}