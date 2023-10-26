namespace LexiconPractice3;

class CustomError : UserError
{
    private string _message;

    public CustomError(string message)
    {
        this._message = message;
    }

    public override string UEMessage()
    {
        return _message;
    }
}