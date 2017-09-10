#pragma once
#include <iostream>

namespace krypton {
class KryptonType {
public:
    /**
     * Writes the type to a BufferWriter
     */
    virtual void write(std::ostream& os) const = 0;

    /**
     * Populates the type with data read from the BufferReader
     */    
    virtual void read(std::istream& is) = 0;
}
}
