using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace lean_csharp
{
    class CollectionsEx
    {
        public void ArrayListExample()
        {
            //object initializer
            var arrayList = new ArrayList() {
                "srinivas", "karre", "Bengaluru"
            };
            

            string[] techs = { "c#", ".net" };

            arrayList.AddRange(techs);

            var queue = new Queue<string>();
            queue.Enqueue("event1");
            queue.Enqueue("event2");

            arrayList.AddRange(queue);

            //printing
            foreach(var key in arrayList)
            {
                Console.WriteLine(key);
            }
        }
        public void DictionaryExample()
        {
            IDictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("karnataka", "Bengaluru");
            dictionary.Add("telanagan", "Hyderabad");

            foreach(KeyValuePair<string, string> stateCity in dictionary)
            {
                Console.WriteLine(stateCity+", state="+stateCity.Key);
            }

            //creating a dictionary using collection-initializer syntax
            //object initializer like static initializer
            var cities = new Dictionary<string, string>(){
                    {"UK", "London, Manchester, Birmingham"},
                    {"USA", "Chicago, New York, Washington"},
                    {"India", "Mumbai, New Delhi, Pune"}
            };

            foreach (KeyValuePair<string, string> stateCity in cities)
            {
                Console.WriteLine(stateCity + ", country=" + stateCity.Key);
            }
        }
    }
}
