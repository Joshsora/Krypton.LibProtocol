#pragma once
#include <iostream>

#if !defined(WRITE_LITTLE_ENDIAN) && !defined(WRITE_BIG_ENDIAN)
#define WRITE_BIG_ENDIAN
#endif

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
};
}
