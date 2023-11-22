import React, { useEffect, useState } from 'react';
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Modal, Form } from 'react-bootstrap';

const Products = () => {
  const [products, setProducts] = useState([]);
  const [selectedProduct, setSelectedProduct] = useState(null);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showDeleteConfirmationModal, setShowDeleteConfirmationModal] = useState(false);
  const [showCreateModal, setShowCreateModal] = useState(false);
  const [newProduct, setNewProduct] = useState({
    name: '',
    price: '',
    description: '',
    imageUrl: '',
  });

  useEffect(() => {
    try {
      axios.get('http://localhost:5065/api/products')
        .then(response => {
          setProducts(response.data);
        })
        .catch(error => {
          console.error(error);
        });
    } catch (error) {
      console.error(error);
    }
  }, []);

  const handleEdit = (product) => {
    setSelectedProduct({ ...product });
    setShowEditModal(true);
  };

  const handleDeleteConfirmation = (product) => {
    setSelectedProduct(product);
    setShowDeleteConfirmationModal(true);
  };

  const handleCreateModal = () => {
    setShowCreateModal(true);
  };

  const handleCreate = async () => {
    try {
      const response = await axios.post('http://localhost:5065/api/products', newProduct);
      setProducts([...products, response.data]);
      setShowCreateModal(false);
      setNewProduct({ name: '', price: '', description: '', imageUrl: '' });
    } catch (error) {
      console.error(error);
    }
  };

  const handleEditModalClose = () => {
    setShowEditModal(false);
    setSelectedProduct(null);
  };

  const handleDelete = () => {
    try {
      axios.delete(`http://localhost:5065/api/products/${selectedProduct.id}`)
        .then(() => {
          const updatedProducts = products.filter(product => product.id !== selectedProduct.id);
          setProducts(updatedProducts);
          setShowDeleteConfirmationModal(false);
          setSelectedProduct(null);
        })
    } catch (error) {
      console.error(error);
    };
  };

  const handleDeleteConfirmationModalClose = () => {
    setShowDeleteConfirmationModal(false);
    setSelectedProduct(null);
  };

  const handleCreateModalClose = () => {
    setShowCreateModal(false);
    setNewProduct({ name: '', price: '', description: '', imageUrl: '' });
  };

  const handleEditSubmit = async () => {
    try {
      const response = await axios.put(`http://localhost:5065/api/products/${selectedProduct.id}`, selectedProduct);
      const updatedProducts = products.map(product =>
        product.id === selectedProduct.id ? response.data : product
      );
      setProducts(updatedProducts);
      setShowEditModal(false);
      setSelectedProduct(null);
    } catch (error) {
      console.error(error);
    }
  };

  return (
    <div>
      <nav className="navbar navbar-expand-sm navbar-light bg-warning">
        <div className="container-fluid">
          <div className="navbar-brand">
            Lista de productos
          </div>
        </div>
      </nav>
      <div className="container">
        <Button variant="primary" className="mt-4" onClick={handleCreateModal}>
          Crear Producto
        </Button>

        <div className="row">
          {products.map((product) => (
            <div key={product.id} className="col-sm-6 mt-4">
              <div className="card mb-3" style={{ maxWidth: '540px' }}>
                <div className="row g-0">
                  <div className="col-md-4">
                    <img src={product.imageUrl} className="img-fluid rounded-start" alt={product.name} />
                  </div>
                  <div className="col-md-8">
                    <div className="card-body">
                      <h5 className="card-title">{product.name}</h5>
                      <h6 className="card-text">Precio: ${product.price}</h6>
                      <p className="card-text">{product.description}</p>
                      <Button variant="warning" onClick={() => handleEdit(product)}>
                        Editar
                      </Button>{' '}
                      <Button variant="danger" onClick={() => handleDeleteConfirmation(product)}>
                        Eliminar
                      </Button>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          ))}
        </div>
      </div>

      <Modal show={showCreateModal} onHide={handleCreateModalClose}>
        <Modal.Header closeButton>
          <Modal.Title>Crear Producto</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formProductName">
              <Form.Label>Nombre</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el nombre"
                value={newProduct.name}
                onChange={(e) => setNewProduct({ ...newProduct, name: e.target.value })}
              />
            </Form.Group>

            <Form.Group controlId="formProductPrice">
              <Form.Label>Precio</Form.Label>
              <Form.Control
                type="number"
                placeholder="Ingrese el precio"
                value={newProduct.price}
                onChange={(e) => setNewProduct({ ...newProduct, price: e.target.value })}
              />
            </Form.Group>

            <Form.Group controlId="formProductDescription">
              <Form.Label>Descripción</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                placeholder="Ingrese la descripción"
                value={newProduct.description}
                onChange={(e) => setNewProduct({ ...newProduct, description: e.target.value })}
              />
            </Form.Group>

            <Form.Group controlId="formProductImageUrl">
              <Form.Label>URL de la Imagen</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese la URL de la imagen"
                value={newProduct.imageUrl}
                onChange={(e) => setNewProduct({ ...newProduct, imageUrl: e.target.value })}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleCreateModalClose}>
            Cancelar
          </Button>
          <Button variant="primary" onClick={handleCreate}>
            Crear
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={showEditModal} onHide={handleEditModalClose}>
        <Modal.Header closeButton>
          <Modal.Title>Editar Producto</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <Form>
            <Form.Group controlId="formProductName">
              <Form.Label>Nombre</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese el nombre"
                value={selectedProduct?.name || ''}
                onChange={(e) => setSelectedProduct({ ...selectedProduct, name: e.target.value })}
              />
            </Form.Group>
            <Form.Group controlId="formProductPrice">
              <Form.Label>Precio</Form.Label>
              <Form.Control
                type="number"
                placeholder="Ingrese el precio"
                value={selectedProduct?.price || ''}
                onChange={(e) => setSelectedProduct({ ...selectedProduct, price: e.target.value })}
              />
            </Form.Group>
            <Form.Group controlId="formProductDescription">
              <Form.Label>Descripción</Form.Label>
              <Form.Control
                as="textarea"
                rows={3}
                placeholder="Ingrese la descripción"
                value={selectedProduct?.description || ''}
                onChange={(e) => setSelectedProduct({ ...selectedProduct, description: e.target.value })}
              />
            </Form.Group>
            <Form.Group controlId="formProductImageUrl">
              <Form.Label>URL de la Imagen</Form.Label>
              <Form.Control
                type="text"
                placeholder="Ingrese la URL de la imagen"
                value={selectedProduct?.imageUrl || ''}
                onChange={(e) => setSelectedProduct({ ...selectedProduct, imageUrl: e.target.value })}
              />
            </Form.Group>
          </Form>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleEditModalClose}>
            Cancelar
          </Button>
          <Button variant="primary" onClick={handleEditSubmit}>
            Guardar cambios
          </Button>
        </Modal.Footer>
      </Modal>

      <Modal show={showDeleteConfirmationModal} onHide={handleDeleteConfirmationModalClose}>
        <Modal.Header closeButton>
          <Modal.Title>Confirmar Eliminación</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <p>¿Estás seguro de que deseas eliminar este producto?</p>
        </Modal.Body>
        <Modal.Footer>
          <Button variant="secondary" onClick={handleDeleteConfirmationModalClose}>
            Cancelar
          </Button>
          <Button variant="danger" onClick={handleDelete}>
            Eliminar
          </Button>
        </Modal.Footer>
      </Modal>
    </div>
  );
};

export default Products;
