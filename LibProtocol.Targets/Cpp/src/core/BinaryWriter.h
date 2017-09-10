#pragma once
#include <ostream>

namespace krypton {
class BinaryWriter {
public:
    BinaryWriter(std::ostream& os);
private:
    std::ostream& m_stream;
}
}
