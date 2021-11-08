using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 反射_序列化
{
    public class Program
    {
        public class Man
        {
            public Man(string name, int age)
            {
                Name = name;
                Age = age;
            }

            public Man(int age)
            {
                Age = age;
            }

            [Required]
            public string Name { get; set; }

            // 值类型，会给默认值0
            [Required]
            public int Age { get; set; }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class RequiredAttribute : System.Attribute
        {
            public static bool IsPropertyRequired(object obj)
            {
                var type = obj.GetType();
                var properties = type.GetProperties();

                foreach (var p in properties)
                {
                    var attribute = p.GetCustomAttributes(typeof(RequiredAttribute), false);
                    if (attribute.Length > 0)
                    {
                        if (p.GetValue(obj, null) == null)
                            return false;
                    }
                }

                return true;
            }
        }


        static void Main(string[] args)
        {
            //var x = new Man("Sum",22);
            var x = new Man(22);
            if (RequiredAttribute.IsPropertyRequired(x))
                Console.WriteLine("Pass !");
            else
                Console.WriteLine("Some required property need set !");

            Console.Read();
        }
    }
}
