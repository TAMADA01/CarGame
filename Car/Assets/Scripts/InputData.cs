public class InputData
{
    private float _horizontal;
    public float Horizontal 
    {
        get => _horizontal; 
        set
        {
            if (value <= 1 && value >= -1) 
            {
                _horizontal = value;
            }
        }

    }

    private float _vertical;
    public float Vertical
    {
        get => _vertical;
        set
        {
            if (value <= 1 && value >= -1)
            {
                _vertical = value;
            }
        }

    }
}
