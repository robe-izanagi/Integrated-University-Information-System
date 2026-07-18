using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace IntegratedUniversityInformationSystem.Repositories
{
    // Generic repository - gumagana sa kahit anong model (T)
    // T = Student, Course, Payment, etc.
    public class JsonRepository<T> where T : class
    {
        private readonly string _filePath; // location ng JSON file
        private List<T> _items;              // data sa memory

        // constructor - cacall kapag gumawa ng repository
        public JsonRepository(string filePath)
        {
            _filePath = filePath;
            LoadData(); // read agad ng data
        }

        // ireread yung JSON file at nilo-load sa memory
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
                    _items = new List<T>();   // walang file, gumawa ng empty list
                    SaveData();     // gumawa ng empty JSON file
                }
            }
            catch (JsonException)
            {
                _items = new List<T>();  // json error
            }
            catch (IOException)
            {
                _items = new List<T>(); // file error
            }
        }

        // mag sasave ng data sa JSON file
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

        // get all records
        public List<T> GetAll()
        {
            return _items;
        }

        // kukunin yung record base sa condition (e.g., s => s.Id == 5)
        public T GetById(Func<T, bool> predicate)
        {
            return _items.FirstOrDefault(predicate);
        }

        // magaadd ng new record
        public void Add(T item)
        {
            _items.Add(item);
            SaveData(); // isasave sa file
        }

        // mag uupdate ng existing record
        public void Update(Func<T, bool> predicate, T updatedItem)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (predicate(_items[i]))
                {
                    _items[i] = updatedItem;  // change nung old items/records
                    SaveData();  // save
                    return;
                }
            }
        }

        // remove data
        public void Delete(T item)
        {
            _items.Remove(item);
            SaveData();
        }

        // remove with condition
        public void DeleteBy(Func<T, bool> predicate)
        {
            var item = _items.FirstOrDefault(predicate);
            if (item != null)
            {
                _items.Remove(item);
                SaveData();
            }
        }

        // reload lang
        public void Refresh()
        {
            LoadData();
        }
    }
}