from pythonosc import dispatcher
from pythonosc import osc_server

dispatcher = dispatcher.Dispatcher()

ip = '127.0.0.1'
port = 4646

# dispatcher that matches message with correct function
dispatcher.map("/simulation", print)

server = osc_server.ThreadingOSCUDPServer(
     (ip, port), dispatcher)
print("Serving on {}".format(server.server_address))

server.serve_forever()