using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSC240_WCFMS04EC
{
    class LinkedList
    {
        private class ListNode
        {
            public Element theData;
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

        public LinkedList(LinkedList originalList)
        {
            ListNode originalNode;
            ListNode copyNode;

            if (originalList.listSize == 0)
            {
                headNode = null;
                listSize = 0;
                return;
            }

            originalNode = originalList.headNode;
            headNode.theData = originalNode.theData.clone();

            originalNode = originalNode.nextNode;
            copyNode = headNode;
            while (originalNode != null)
            {
                copyNode.nextNode = new CSC240_WCFMS04EC.LinkedList.ListNode();
                copyNode = copyNode.nextNode;

                copyNode.theData = originalNode.theData.clone();
                originalNode = originalNode.nextNode;
            }

            listSize = originalList.listSize;
        }

        public int size()
        {
            return listSize;
        }

        public Element get(int pos)
        {
            ListNode nodeWeWant;

            nodeWeWant = seek(pos);

            if (nodeWeWant == null)
            {
                return null;
            }
            else
            {
                return nodeWeWant.theData.clone();
            }
        }

        public bool insert(Element anElement, int pos)
        {
            ListNode prevNode;
            ListNode newNode;

            if((pos < 1) || (pos > listSize + 1))
            {
                return false;
            }

            newNode = new ListNode();
            newNode.theData = anElement.clone();

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

        public bool replace(Element anElement, int pos)
        {
            ListNode nodeWeWant;

            nodeWeWant = seek(pos);

            if (nodeWeWant == null)
            {
                return false;
            }
            else
            {
                nodeWeWant.theData = anElement.clone();
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
                    currNode.theData.display();
                    currNode = currNode.nextNode;
                }
            }
        }
    }
}
