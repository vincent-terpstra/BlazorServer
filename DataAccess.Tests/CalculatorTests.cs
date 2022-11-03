using System;
using Xunit;

namespace DataAccess.Tests;
using DataAccess;

public class CalculatorTests
{
    [Fact]
    public void Subtract_SimpleValues_ShouldCalculate()
    {
        //Arrange
        double x = 5, y = 10;
        double expected = -5;
        //Note this is only testing that Subtract returns -5
        
        //Act
        double actual = Calculator.Subtract(x, y);
        
        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(5, 5, 10)]
    [InlineData(2, 3, 5)]
    public void Add_SimpleValues_Should_Calculate(double x, double y, double expected)
    {
        //Arrange
        
        //Act
        double actual = Calculator.Add(x, y);
        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(5, 5, 25)]
    [InlineData(2, -3, -6)]
    public void Multiply_SimpleValues_Should_Calculate(double x, double y, double expected)
    {
        //Arrange
        
        //Act
        double actual = Calculator.Multiply(x, y);
        //Assert
        Assert.Equal(expected, actual);
    }
    
    [Theory]
    [InlineData(5, -5, -1)]
    [InlineData(10, 20, .5)]
    public void Divide_SimpleValues_Should_Calculate(double x, double y, double expected)
    {
        //Arrange
        
        //Act
        double actual = Calculator.Divide(x, y);
        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Divide_Should_Throw_When_Y_Is_Zero()
    {
        //Arrange
        double x = 5;
        double y = 0;
        
        //Act
        
        //Assert
        //note normally dividing by zero returns double.PositiveInfinity
        Assert.Throws<DivideByZeroException>(() =>Calculator.Divide(x, y));
    }
}