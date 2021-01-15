using System;

namespace Models
{
    public class ViewModeSelector
    {
        public static IBook Create(Book book, string className)
        {
            switch(className)
            {
                case "SingleViewMode":
                    return new SingleViewMode(book);
                case "DualViewMode":
                    return new DualViewMode(book);
                case "SquareViewMode":
                    return new SquareViewMode(book);
                default:
                    throw new Exception();
            }
        }
    }
}