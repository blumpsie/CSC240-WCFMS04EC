/*
 * Exactly the same as Element.java, hopefully they work exaclty the same too.
 */
namespace CSC240_WCFMS04EC
{
    abstract class Element
    {
        public string getClassName()
        {
            return GetType().Name;
        }

        public abstract void readIn();

        public abstract void display();

        public abstract Element clone();

        public abstract override string ToString();
    }
}
