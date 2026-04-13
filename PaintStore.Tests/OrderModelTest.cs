using System;
using FluentAssertions;
using PaintStore.Models;

namespace PaintStore.Tests;

public class OrderModelTest
{
    [Fact]
    public void TotalPrice_WhenNoPaintProducts_ShouldBeZero()
    {
        //Arrange
        var order = new Order();
    

        //Act & Assert
        order.TotalPrice.Should().Be(0);    
    }

    [Fact]
    public void TotalPrice_WhenOnePaintProduct_ShouldBeProductPrice()
    {
        //Arrange
        var order = new Order();
        var paintProduct = new PaintProduct("Red Paint", 19.99m);
        
        order.PaintProducts.Add(paintProduct);

        //Act & Assert
        order.TotalPrice.Should().Be(19.99m);
    }
}
