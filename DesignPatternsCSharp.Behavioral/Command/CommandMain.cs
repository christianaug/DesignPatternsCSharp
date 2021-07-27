﻿using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Business.Commands;
using ShoppingCart.Business.Repositories;

namespace DesignPatternsCSharp.Behavioral.Command
{
	public class CommandMain
	{
		public static void CommandMainRunner()
        {
            //repository pattern
            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductsRepository();

            var product = productsRepository.FindBy("SM7B");
            //invokes a command
            var addToCartCommand = new AddToCartCommand(shoppingCartRepository,
                productsRepository,
                product);

            var increaseQuantityCommand = new ChangeQuantityCommand(
                ChangeQuantityCommand.Operation.Increase,
                shoppingCartRepository,
                productsRepository,
                product);

            var manager = new CommandManager();
            manager.Invoke(addToCartCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);

            PrintCart(shoppingCartRepository);

            manager.Undo();

            PrintCart(shoppingCartRepository);
        }

        static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            var totalPrice = 0m;
            foreach (var lineItem in shoppingCartRepository.LineItems)
            {
                var price = lineItem.Value.Product.Price * lineItem.Value.Quantity;

                Console.WriteLine($"{lineItem.Key} " +
                    $"${lineItem.Value.Product.Price} x {lineItem.Value.Quantity} = ${price}");

                totalPrice += price;
            }

            Console.WriteLine($"Total price:\t${totalPrice}");
        }
    }
}
