#pragma once
#include <istream>

namespace krypton {
class BinaryReader {
public:
    BinaryReader(std::istream& is);
private:
    std::istream& m_stream;
}
}
