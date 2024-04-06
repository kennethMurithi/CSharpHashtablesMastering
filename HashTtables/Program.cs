using System;
using System.Collections;

namespace Hashtables
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable studentsTable = new Hashtable();

            Student[] students = new Student[6];
            students[0] = new Student(1, "Murithi", 98);
            students[1] = new Student(2, "Carson", 76);
            students[2] = new Student(6, "Mavrick", 43);
            students[3] = new Student(1, "Jason", 55);
            students[4] = new Student(3, "Tyson", 43);
            students[5] = new Student(4, "Matthew", 55);

            foreach (Student s in students)
            {
                if (!studentsTable.ContainsKey(s.Id))
                {
                    studentsTable.Add(s.Id, s);
                    Console.WriteLine("Student with ID {0} was added!.", s.Id);
                }
                else
                {
                    Console.WriteLine("Sorry, A student with the same ID already exists ID:{0}", s.Id);
                }
            }

            Employee[] employees =
            {
                new Employee("CEO","Sharon",95,200),
                new Employee("Manager","Joy",95,260),
                new Employee("HR","Martin",55,120),
                new Employee("Secretary","Petra",45,90),
                new Employee("Lead Developer","Joshua",70,270),
                new Employee("Intern","Ernest",30,50),
            };

            Dictionary<string, Employee> employeeDirectory = new Dictionary<string, Employee>();

            foreach (Employee emp in employees)
            {
                employeeDirectory.Add(emp.Role, emp);
            }

            string key = "HR";
            if (employeeDirectory.ContainsKey(key))
            {
                Employee emp1 = employeeDirectory[key];
                Console.WriteLine("\nEmployee Name: {0}, Role {1}, Salary: {2}", emp1.Name, emp1.Role, emp1.Salary);
            }
            else
            {
                Console.WriteLine("No Employee found with this Key {0}", key);
            }


            Employee result = null;
            if (employeeDirectory.TryGetValue("Intern", out result))
            {             
                Console.WriteLine("\nEmployee Name: {0}, Role {1}, Salary: {2}", result.Name, result.Role, result.Salary);
            }
            else
            {
                Console.WriteLine("No Employee found with this Key {0}", key);
            }

            string keyToUpdate = "HR";
            if (employeeDirectory.ContainsKey(keyToUpdate))
            {
                employeeDirectory[keyToUpdate] = new Employee("HR", "Carol", 26, 18);
                Console.WriteLine("Employee with Role/Key {0} was Updated",keyToUpdate);
            }
            else
            {
                Console.WriteLine("No employee found with this key {0}", keyToUpdate);
            }

            string keyToRemove = "Intern";
            if (employeeDirectory.Remove(keyToRemove))
            {
                Console.WriteLine("Employee with Role/Key {0} was Removed", keyToRemove);
            }
            else
            {
                Console.WriteLine("No employee found with this key {0}", keyToRemove);
            }

            for (int i = 0; i < employeeDirectory.Count; i++)
            {
                KeyValuePair<string, Employee> keyValuePair = employeeDirectory.ElementAt(i);

                Employee employeeValue = keyValuePair.Value;

                Console.WriteLine("\nEmployee Name: {0}, Role {1}, Salary: {2}", employeeValue.Name, employeeValue.Role, employeeValue.Salary);
            }


            Dictionary<int, string> myDictionary = new Dictionary<int, string>()
            {
                {1,"one" },
                {2,"two"},
                {3,"three" }
            };

            /*
            Student storedStudent1 = (Student)studentsTable[stud1.Id];

            // retrieve all values from a Hashtable
            foreach (DictionaryEntry entry in studentsTable)
            {
                Student temp = (Student)entry.Value;
                Console.WriteLine("Stident ID:{0}, Name:{1}, GPA{2}",temp.Id, temp.Name, temp.GPA);
            }*/

            string valuetest = ConvertTest(5);
            Console.WriteLine("Value Test ID:{0}", valuetest);

            Console.WriteLine("\n\n-------------------------------------------------------------");
            Queue<Order> ordersQueue = new Queue<Order>();

            foreach (Order item in ReceiveOrdersFromBranch1())
            {
                ordersQueue.Enqueue(item);
            }

            foreach (Order item in ReceiveOrdersFromBranch2())
            {
                ordersQueue.Enqueue(item);
            }

            while (ordersQueue.Count > 0)
            {
                Order currentOrder = ordersQueue.Dequeue();
                currentOrder.ProcessOrder();
            }
        }


        public static string ConvertTest(int i)
        {
            Dictionary<int, string> numbers = new Dictionary<int, string>(){
                {0,"ozero"},
                {1,"one"},
                {2,"two"},
                {3,"three"},
                {4,"four"},
                {5,"five"},
            };

            if (numbers.ContainsKey(i))
            {
                string result = numbers[i];
                return result;
            }
            else
            {
                return "nope";
            }
        }

        static Order[] ReceiveOrdersFromBranch1()
        {
            Order[] orders = new Order[]
            {
                new Order(1,5),
                new Order(2,4),
                new Order(6,10),
            };

            return orders;
        }

        static Order[] ReceiveOrdersFromBranch2()
        {
            Order[] orders = new Order[]
            {
                new Order(3,5),
                new Order(4,4),
                new Order(5,10),
            };

            return orders;
        }
    }

    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public float GPA { get; set; }

        public Student(int id, string name, float GPA)
        {
            this.Id = id;
            this.Name = name;
            this.GPA = GPA;
        }
    }

    class Employee
    {
        public string Role { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public float Rate { get; set; }
        public float Salary
        {
            get
            {
                return Rate * 8 * 5 * 4 * 12;
            }
        }

        public Employee(string role, string name, int age, float rate)
        {
            this.Role = role;
            this.Name = name;
            this.Age = age;
            this.Rate = rate;
        }

        
    }

    class Order
    {
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }


        public Order(int id, int orderQuantity)
        {
            this.OrderId = id;
            this.OrderQuantity = orderQuantity;
        }   

        public void ProcessOrder()
        {
            Console.WriteLine($"Order {OrderId} processed!.");
        }
    }
}