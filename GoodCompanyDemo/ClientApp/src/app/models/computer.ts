export interface IComputer {
  id: string;
  typeName: string;
  brand: string;
  processorName: string;
  quantity: number;
  usbPorts: number;
  ramSlots: number;
  imageUrl: string;
  screenSize: number;
}

export class Computer {
  public id: string;
  public typeName: string;
  public brand: string;
  public processorName: string;
  public quantity: number;
  public usbPorts: number;
  public ramSlots: number;
  public imageUrl: string;
  public screenSize: number;

  constructor(
    typeName: string,
    brand: string,
    processorName: string,
    quantity: number,
    usbPorts: number,
    ramSlots: number,
    imageUrl: string,
    screenSize: number
  ) {
    this.typeName = typeName;
    this.brand = brand;
    this.processorName = processorName;
    this.quantity = quantity;
    this.usbPorts = usbPorts;
    this.ramSlots = ramSlots;
    this.imageUrl = imageUrl;
    this.screenSize = screenSize;
  }
}
