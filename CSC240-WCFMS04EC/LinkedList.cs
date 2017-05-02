using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS04EC
{
    class LinkedList<T>
    {
        private class ListNode
        {
            public T theData;
            public ListNode nextNode;
        }

        // Fields
        private ListNode headNode;
        public int listSize;

        private ListNode seek(int pos)
        {
            ListNode theResult;
            int counter;

            if((pos < 1) || (pos > listSize))
            {
                return null;
            }

            theResult = headNode;
            counter = 1;
            while(counter < pos)
            {
                theResult = theResult.nextNode;
                counter++;
            }

            return theResult;
        }

        // Default Contstructor
        public LinkedList()
        {
            listSize = 0;
        }

        public int size()
        {
            return listSize;
        }

        public T get(int pos)
        {
            ListNode nodeWeWant;

            nodeWeWant = seek(pos);

            if (nodeWeWant == null)
            {
                return default(T);
            }
            else
            {
                return nodeWeWant.theData;
            }
        }

        public bool insert(T aT, int pos)
        {
            ListNode prevNode;
            ListNode newNode;

            if((pos < 1) || (pos > listSize + 1))
            {
                return false;
            }

            newNode = new ListNode();
            newNode.theData = aT;

            if (pos == 1)
            {
                newNode.nextNode = headNode;
                headNode = newNode;
            }
            else
            {
                prevNode = seek(pos - 1);
                newNode.nextNode = prevNode.nextNode;
                prevNode.nextNode = newNode;
            }

            listSize++;
            return true;
        }

        public bool replace(T aT, int pos)
        {
            ListNode nodeWeWant;

            nodeWeWant = seek(pos);

            if (nodeWeWant == null)
            {
                return false;
            }
            else
            {
                nodeWeWant.theData = aT;
                return true;
            }
        }

        public bool remove(int pos)
        {
            ListNode nodeToRemove;
            ListNode prevNode;

            if ((pos < 1) || (pos > listSize))
            {
                return false;
            }

            if (pos == 1)
            {
                headNode = headNode.nextNode;
            }
            else
            {
                prevNode = seek(pos - 1);
                nodeToRemove = prevNode.nextNode;
                prevNode.nextNode = nodeToRemove.nextNode;
            }

            listSize--;
            return true;
        }

        public void removeAll()
        {
            headNode = null;
            listSize = 0;
        }

        public void display()
        {
            ListNode currNode;

            if (listSize == 0)
            {
                Console.WriteLine("There are no objects in this list. ");
            }
            else
            {
                Console.WriteLine("Here are the objects in the list: \n");
                currNode = headNode;
                while (currNode != null)
                {
                    currNode.theData.ToString();
                    currNode = currNode.nextNode;
                }
            }
        }

        private bool isAlreadyInList(T aT)
        {

        }

        public bool removeAnObject(T aT)
        {

        }

        public bool editAnObject(T aT)
        {

        }
    }
}
