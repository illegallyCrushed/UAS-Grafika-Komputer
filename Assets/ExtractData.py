#made by nsv
import bpy

def generateObject(object, file, order):
    callout = order
    name = object.name.split("-")
    if name[0] == "Ignore" or len(name) < 2:
        return
    else:
        file.write(callout+"addChild(new Object(\"{}\"));\n".format(name[1]))
        if name[0] == "Plane":
            file.write(callout+"lastChild().createPlane();\n")
        elif name[0] == "Cube":
            file.write(callout+"lastChild().createCube();\n")
        elif name[0] == "Circle":
            file.write(callout+"lastChild().createCircle();\n")
        elif name[0] == "Sphere":
            file.write(callout+"lastChild().createBall();\n")
        elif name[0] == "Cylinder":
            file.write(callout+"lastChild().createCylinder();\n")
        elif name[0] == "Cone":
            file.write(callout+"lastChild().createCone();\n")
        elif name[0] == "Torus":
            if len(name) == 2:
                file.write(callout+"lastChild().createTorus();\n")
            else:
                file.write(callout+"lastChild().createTorus(1f,{}f);\n".format(name[2]))
        elif name[0] == "Triangle":
            file.write(callout+"lastChild().createTriangle();\n")
        elif name[0] == "RightTriangle":
            file.write(callout+"lastChild().createTriangle(true);\n")
        elif name[0] == "HalfCircle":
            file.write(callout+"lastChild().createCircle(0.5f);\n")
        elif name[0] == "HalfSphere":
            file.write(callout+"lastChild().createBall(0.5f);\n")
        elif name[0] == "HalfCylinder":
            file.write(callout+"lastChild().createCylinder(0.5f);\n")
        elif name[0] == "HalfCone":
            file.write(callout+"lastChild().createCone(0.5f);\n")
        elif name[0] == "HalfTorus":
            if len(name) == 2:
                file.write(callout+"lastChild().createTorus(0.5f);\n")
            else:
                file.write(callout+"lastChild().createTorus(0.5f,{}f);\n".format(name[2]))
        elif name[0] == "BezierCurve":
            file.write(callout+"lastChild().createFreeformTube(new List<Vector2> {\n")
            object.data.dimensions = "2D"
            object.data.render_resolution_u = 5
            object.data.render_resolution_v = 5
            object.data.resolution_u = 5
            object.data.resolution_v = 5
            curvetemp = object.to_mesh()
            for vert in curvetemp.vertices:
                file.write(("\t\t\t\t"*len(order.split(".")))+"new Vector2({:.5f}f, {:.5f}f),\n".format(vert.co[0],vert.co[1]))
            if len(name) == 2:
                file.write(("\t\t\t"*len(order.split(".")))+"});\n")
            else:
                file.write(("\t\t\t"*len(order.split(".")))+"{},1f,{}f);\n".format("}",name[2]))
        elif name[0] == "Parent":
            file.write("\n{} // Children of \'{}\'\n\n".format("{",name[1]))
            for child in object.children:
                generateObject(child,file,"\t\t\t" + order +"lastChild().")
            file.write("{} // Children of \'{}\'\n\n".format("}",name[1]))
        else:
            return

        if callout == "scene." :
            file.write(callout+"lastChild().scale({:.5f}f, {:.5f}f, {:.5f}f);\n".format(object.matrix_local.to_scale()[0],object.matrix_local.to_scale()[1],object.matrix_local.to_scale()[2]))
            file.write(callout+"lastChild().rotateQ({:.5f}f, {:.5f}f, {:.5f}f,{:.5f}f);\n".format(object.matrix_local.to_quaternion()[0],object.matrix_local.to_quaternion()[1],object.matrix_local.to_quaternion()[2],object.matrix_local.to_quaternion()[3]))
            file.write(callout+"lastChild().translate({:.5f}f, {:.5f}f, {:.5f}f);\n".format(object.matrix_local.translation[0],object.matrix_local.translation[1],object.matrix_local.translation[2]))
        else:
            file.write(callout+"lastChild().scale({:.5f}f, {:.5f}f, {:.5f}f);\n".format(object.matrix_local.to_scale()[0],object.matrix_local.to_scale()[1],object.matrix_local.to_scale()[2]))
            file.write(callout+"lastChild().rotateQ({:.5f}f, {:.5f}f, {:.5f}f,{:.5f}f);\n".format(object.matrix_local.to_quaternion()[0],object.matrix_local.to_quaternion()[1],object.matrix_local.to_quaternion()[2],object.matrix_local.to_quaternion()[3]))
            file.write(callout+"lastChild().translate({:.5f}f, {:.5f}f, {:.5f}f);\n".format(object.matrix_local.translation[0],object.matrix_local.translation[1],object.matrix_local.translation[2]))
        
        file.write(callout+"lastChild().centerOrigin();\n")
        
        try:
            nodes = object.material_slots[0].material.node_tree.nodes
            principled = next(n for n in nodes if n.type == 'BSDF_PRINCIPLED')
            base_color = principled.inputs[0]
            value = base_color.default_value
            file.write(callout+"lastChild().setColor({:.5f}f, {:.5f}f, {:.5f}f);\n".format(value[0], value[1], value[2])) 
        except:
            file.write(callout+"lastChild().setColor(1.0f, 1.0f, 0.0f);\n")
        file.write("\n")

file = open(bpy.data.filepath+".txt","w")
collections = bpy.data.collections

for collection in collections:
    for object in collection.all_objects:
        if object.parent == None:
            generateObject(object,file,"scene.")

file.close()