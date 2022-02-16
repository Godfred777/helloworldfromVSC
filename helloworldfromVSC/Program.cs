using System;

namespace helloworldfromVSC
{
    
    class Node<T>
    {
        //This is the a single node for building a Linkedlist data structure
        public T data; //Data of generic data type
        public Node<T> nextNode; //Node reference to the next node

        public Node(T data)
        {
            //The constructor makes it easier initialize nodes before joining the Linkedlist chain
            this.data = data;

        } 

    }
    /*
     The Linkedlist data structure keeps node linked like a chain. 
     Any data added in to the Linked list would stored in a newly initialized node linked in to hte Linkedlist
     */
    class LinkList<T>
    {
        Node<T> head = null; //Initializes the head node

        public int Size()
        {
            //Returns the size of the Linkedlist by counting the number of nodes in the list
            //Operation is linear time[O(n)]
            int count = 0; 
            Node<T> current = head;
            while (current != null)
            {
                count++;
                current = current.nextNode;
            }
            return count;
        }

        public void Add(T data)
        {
            //Initializes and adds a new node in the Linkedlist data structure
            //Total operation takes O(n)
            Node<T> node = new Node<T>(data);
            
            if (head == null)
            {
                head = node;
            } else
            {
                Node<T> current = head;
                while (current != null)
                {
                    if (current.nextNode == null)
                    {
                        current.nextNode = node;
                        break;
                    }
                    current = current.nextNode;
                }

            }
        }

        public void Insert(T data, int index)
        {
            if (index == Size())
            {
                Add(data);
            } else
            {
                int count = 0;
                Node<T> current = head;
                Node<T> newNode = new Node<T>(data);

                while (current != null)
                {
                    if (count == index)
                    {
                        current = newNode;
                        newNode.nextNode = current;
                        count++;
                        break;
                    }
                    current = current.nextNode;
                    count++;
                }
            }
        }

        public void Remove(int index)
        {
            //Removes the a node at the indicated index
            //Total operation takes O(n)
            if (index == 0)
            {
                head = head.nextNode;
            } else
            {
                Node<T> current = head;
                Node<T> previous = null;
                int count = 0;

                while (current != null)
                {
                    if (count == index)
                    {
                        previous.nextNode = current.nextNode;
                        break;
                    }
                    previous = current;
                    current = current.nextNode;
                    count++;
                }
            }
        }

        public T NodeAtIndex(int index)
        {
            //This is a search algorithm that returns the data of the node of the given index
            //Total operation is O(n)
            Node<T> current = head;
            int count = 0;

            while (current != null)
            {
                if (count == index)
                {
                    break;
                }

                current = current.nextNode;
                count++;
            }
            return current.data;

        }
        
        public void Display()
        {
            //Displays the data stored in the Linkedlist iteratively
            Node<T> current = head;
            while (current != null)
            {
                Console.WriteLine(current.data);
                current = current.nextNode;
            }
        }
    }

    

    class Program
    {

        static void Main(string[] args)
        {
            LinkList<int> numbers = new LinkList<int>();
            numbers.Add(5);
            numbers.Add(2);
            numbers.Add(6);
            numbers.Add(3);
            numbers.Add(1);
            Console.WriteLine(numbers.Size());
            numbers.Remove(3);
            Console.WriteLine(numbers.Size());
            Console.WriteLine(numbers.NodeAtIndex(2));
            numbers.Insert(8, 3);
            Console.WriteLine("=====================");
            numbers.Display();
            Console.WriteLine("=====================");
        }
    }
}

