﻿using IGI_Web_953501_Smolyar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_Web_953501_Smolyar.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }
        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        public int Cost
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity *
                item.Value.drink.Cost);
            }
        }
        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="drink">добавляемый объект</param>
        public virtual void AddToCart(Drink drink)
        {

            // если объект есть в корзине
            // то увеличить количество

            if (Items.ContainsKey(drink.Id))
                Items[drink.Id].Quantity++;
            // иначе - добавить объект в корзину

            else
                Items.Add(drink.Id, new CartItem
                {
                    drink = drink,
                    Quantity = 1
                });

        }
        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }
        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }
    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Drink drink { get; set; }
        public int Quantity { get; set; }
    }
}