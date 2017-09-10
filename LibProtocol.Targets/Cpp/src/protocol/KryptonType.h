#pragma once

namespace krypton {
class BinaryWriter;
class BinaryReader;
}

namespace krypton.protocol {
class KryptonType {
public:
    /**
     * Writes the type to a BufferWriter
     */
    virtual void write(BinaryWriter& bw) const = 0;

    /**
     * Populates the type with data read from the BufferReader
     */    
    virtual void read(BinaryReader& br) = 0;
}
}
