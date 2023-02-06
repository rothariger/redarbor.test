using System;

public class AddCandidateCommandHandler
{
    private readonly RedarborContext _context;

    public AddProductCommandHandler(RedarborContext context)
    {
        _context = context;
    }

    public void Handle(AddProductCommand command)
    {
        var product = new Product
        {
            Name = command.Name,
            Price = command.Price,
            Stock = command.Stock
        };
        _context.Products.Add(product);
        _context.SaveChanges();
    }
}
