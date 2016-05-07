using System.Collections.Generic;
using System.ComponentModel;

namespace EventEditor {

    static class BindingExtension {
        public static BindingList<T> ToBindingList<T>(this IEnumerable<T> ien)
        {
            var list = new BindingList<T>();

            foreach (var item in ien)
            {
                list.Add(item);
            }

            return list;
        }
    }
}