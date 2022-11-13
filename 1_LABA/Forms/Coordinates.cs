namespace _1_LABA.Forms;

public struct Coordinates
{
    public const int ButtonMoveStep = 5;
    public readonly int FormWidth;
    public readonly int FormHeight;
    public readonly int Width;
    public readonly int Height;
    public readonly int MiddleX;
    public readonly int MiddleY;

    public Coordinates(int formWidth, int formHeight, int width, int height)
    {
        FormWidth = formWidth - 9 - ButtonMoveStep;
        FormHeight = formHeight - 38 - ButtonMoveStep;
        Width = width;
        Height = height;
        MiddleX = width / 2;
        MiddleY = height / 2;
    }
}