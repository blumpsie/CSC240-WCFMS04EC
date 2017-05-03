using System;

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

        public int insert(T aT, int pos)
        {
            ListNode prevNode;
            ListNode newNode;

            if((pos < 1) || (pos > listSize + 1))
            {
                return -1;
            }

            newNode = new ListNode();
            newNode.theData = aT;

            if(isAlreadyInList(aT))
            {
                return -2;
            }

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
            return 0;
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
            T currT;
            string paramClass = aT.GetType().Name;
            string currClass;

            for (int i = 1; i <= listSize; i++)
            {
                currT = get(i);
                currClass = currT.GetType().Name;

                if (paramClass.Equals(currClass))
                {
                    if (currT.Equals(aT))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool removeAnObject(T aT)
        {
            bool removed = false;

                T currT;
                string paramClass = aT.GetType().Name;
                string currClass;

                for (int i = 1; i <= listSize; i++)
                {
                    currT = get(i);
                    currClass = currT.GetType().Name;

                    if (paramClass.Equals(currClass))
                    {
                        if (currT.Equals(aT))
                        {
                            remove(i);
                            removed = true;
                        }
                    }
                }
                return removed;
    }

        public bool editAnObject(T aT)
        {
            bool edited = false;

                T currT;
                string paramClass = aT.GetType().Name;
                string currClass;

                for (int i = 1; i <= listSize; i++)
                {
                    currT = get(i);
                    currClass = currT.GetType().Name;

                    if (paramClass.Equals(currClass))
                    {
                        if (currT.Equals(aT))
                        {
                        Console.WriteLine("FUCK!!!!!!!!!!!!!!!");
                        replace(aT, i);
                            edited = true;
                        }
                    }
                }
                return edited;
        }
    }
}
