using System;
using System.Drawing;
using System.Windows.Forms;

public class ClockForm : Form
{
    private Timer timer;
    
    public ClockForm()
    {
        this.Text = "Годинник";
        this.Size = new Size(300, 300);
        this.Paint += ClockForm_Paint;
        
        timer = new Timer();
        timer.Interval = 1000;
        timer.Tick += Timer_Tick;
        timer.Start();
    }
    
    private void Timer_Tick(object sender, EventArgs e)
    {
        this.Invalidate();
    }
    
    private void ClockForm_Paint(object sender, PaintEventArgs e)
    {
        Graphics graphics = e.Graphics;
        DateTime currentTime = DateTime.Now;
        
        int centerX = this.ClientSize.Width / 2;
        int centerY = this.ClientSize.Height / 2;
        int radius = Math.Min(centerX, centerY) - 10;
        
 
        graphics.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);
        
        int hourHandLength = radius / 2;
        double hourAngle = (currentTime.Hour % 12 + currentTime.Minute / 60.0) * 30;
        int hourHandX = centerX + (int)(hourHandLength * Math.Sin(hourAngle * Math.PI / 180));
        int hourHandY = centerY - (int)(hourHandLength * Math.Cos(hourAngle * Math.PI / 180));
        graphics.DrawLine(Pens.Black, centerX, centerY, hourHandX, hourHandY);
        
        int minuteHandLength = radius * 3 / 4;
        double minuteAngle = (currentTime.Minute + currentTime.Second / 60.0) * 6;
        int minuteHandX = centerX + (int)(minuteHandLength * Math.Sin(minuteAngle * Math.PI / 180));
        int minuteHandY = centerY - (int)(minuteHandLength * Math.Cos(minuteAngle * Math.PI / 180));
        graphics.DrawLine(Pens.Black, centerX, centerY, minuteHandX, minuteHandY);
        
        int secondHandLength = radius * 5 / 6;
        double secondAngle = currentTime.Second * 6;
        int secondHandX = centerX + (int)(secondHandLength * Math.Sin(secondAngle * Math.PI / 180));
        int secondHandY = centerY - (int)(secondHandLength * Math.Cos(secondAngle * Math.PI / 180));
        graphics.DrawLine(Pens.Red, centerX, centerY, secondHandX, secondHandY);
    }
    
    public static void Main()
    {
        Application.Run(new ClockForm());
    }
}
