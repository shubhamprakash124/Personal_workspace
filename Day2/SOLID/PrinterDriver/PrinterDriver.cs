public class PrinterDriver {
    private Printer printer;
    private IInputDevice device;
 
    public PrinterDriver(Printer printer, IInputDevice device) {
        this.printer = printer;
        this.device = device;
    }
 
    public void print() {
        while (!device.isEndOfData()) { 
            printer.print(device.readPage());
        }
    }
}
 
interface IInputDevice {
    String readPage();  // Changed `buffer` to `String`
    boolean isEndOfData();
}
 
class FileInput implements IInputDevice {
    private String path;
    private BufferedReader reader;
 
    public FileInput(String path) throws IOException {
        this.path = path;
        this.reader = new BufferedReader(new FileReader(path));
    }
 
    @Override
    public String readPage() {
        try {
            return reader.readLine();
        } catch (IOException e) {
            e.printStackTrace();
            return null;
        }
    }
 
    @Override
    public boolean isEndOfData() {
        try {
            return !reader.ready();
        } catch (IOException e) {
            e.printStackTrace();
            return true;
        }
    }
}
 
class ScannerService implements IInputDevice {
    private Scanner scanner;
 
    public ScannerService() {
        this.scanner = new Scanner(System.in); // Assuming standard input
    }
 
    @Override
    public String readPage() {
        return scanner.nextLine();
    }
 
    @Override
    public boolean isEndOfData() {
        return !scanner.hasNextLine();
    }
}
 
class FaxService implements IInputDevice {
    private Fax fax;
 
    public FaxService() {
        this.fax = new Fax();
    }
 
    @Override
    public String readPage() {
        return fax.receive();
    }
 
    @Override
    public boolean isEndOfData() {
        return fax.isEndOfData();
    }
}
