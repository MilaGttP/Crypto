﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Crypto
{
    public interface ISwitchable { void UtilizeState(object state); }
    public class Switcher
    {
        public static MainWindow pageSwitcher;
        public static void Switch(UserControl newPage) => pageSwitcher.Navigate(newPage);
        public static void Switch(UserControl newPage, object state) => pageSwitcher.Navigate(newPage, state);
    }
}
