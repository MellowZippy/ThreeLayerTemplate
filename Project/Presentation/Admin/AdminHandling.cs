static class AdminHandling
{
    public static void AdminCommandHandling(string command)
    {

        switch (command.ToUpper())
        {
            case "A": break;
            case "B": break;
            case "C": break;
            case "D": break;
            case "E": break;
            case "F": break;
            case "1": break;
            case "2": break;
            case "3": break;
            case "BACK": break;
            default: AdminGUI.AdminUI(); break;
        }
    }
}