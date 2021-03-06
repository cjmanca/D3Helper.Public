﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Enigma.D3.Helpers;
using Enigma.D3.UI.Controls;
using Enigma.D3;
using Enigma.D3.UI;

namespace D3Helper.A_Tools
{
    public class InventoryItemSlot
    {
        public InventoryItemSlot(int itemSlotX, int itemSlotY)
        {
            this.ItemSlotX = itemSlotX;
            this.ItemSlotY = itemSlotY;

        }

        public int ItemSlotX { get; set; }
        public int ItemSlotY { get; set; }

    }
    class T_D3UI
    {
        public class UIElement
        {
            public static bool isVisible(string ControlName)
            {
                try
                {
                    return UXHelper.GetControl<UXChatEditLine>(ControlName).IsVisible();
                }
                catch { return false; }
            }
            public static UIRect getRect(string control)
            {
                
                try
                {
                    if (A_Collection.Environment.Scene.GameTick > 1 && A_Collection.Environment.Scene.Counter_CurrentFrame != 0)
                    {
                        
                        UXItemsControl _control = UXHelper.GetControl<UXItemsControl>(control);
                        UIRect rect = _control.x468_UIRect.TranslateToClientRect(Engine.Current.VideoPreferences.x0C_DisplayMode.x20_Width, Engine.Current.VideoPreferences.x0C_DisplayMode.x24_Height);
                        return rect;
                    }
                    return default(UIRect);
                }
                catch { return default(UIRect); }

            }
        }
        public class Inventory
        {
            public static UIRect get_InventoryUIRect()
            {
                var Inventory = "Root.NormalLayer.inventory_dialog_mainPage.inventory_button_backpack";
                return UIElement.getRect(Inventory);
            }
            public static void create_InventoryMesh()
            {
                var Inventory = "Root.NormalLayer.inventory_dialog_mainPage.inventory_button_backpack";
                var inventoryUIRect = UIElement.getRect(Inventory);
                var inventoryRectLeft = inventoryUIRect.Left;
                var inventoryRectTop = inventoryUIRect.Top;
                var inventoryRectRight = inventoryUIRect.Right;
                var inventoryRectBottom = inventoryUIRect.Bottom;

                var itemSlotX = (inventoryRectRight - inventoryRectLeft) / 10;
                var itemSlotY = (inventoryRectBottom - inventoryRectTop) / 6;

                for (int iX = 0; iX <= 9; iX++)
                {
                    for (int iY = 0; iY <= 5; iY++)
                    {
                        UIRect newItemSlot = new UIRect();
                        newItemSlot.Left = inventoryRectLeft + (itemSlotX * iX);
                        newItemSlot.Right = inventoryRectLeft + (itemSlotX * (iX + 1));

                        newItemSlot.Top = inventoryRectTop + (itemSlotY * iY);
                        newItemSlot.Bottom = inventoryRectTop + (itemSlotY * (iY + 1));

                        A_Collection.D3UI.InventoryItemUIRectMesh.Add(new InventoryItemSlot(iX, iY), newItemSlot);
                    }
                }


            }
        }
    }
}
